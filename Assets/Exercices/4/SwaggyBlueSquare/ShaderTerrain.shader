// UNITY_SHADER_NO_UPGRADE

Shader "8TRD150/ShaderTerrain"
{
    Properties
    {
		_MainTex("Texture", 2D) = "white" {}
		_TexAltitude("Altitude", 2D) = "white" {}


    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        LOD 100

        Pass
        {
			Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
			#pragma vertex vert
            #pragma fragment frag
			#pragma glsl

			#include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
            };		

            struct v2f
            {
				float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            float4x4 modelMatrix;

			sampler2D _MainTex;
			sampler2D _TexAltitude;

			float4 _MainTex_ST;

			float time;
			float _Scale;


            v2f vert (appdata v)
            {
                v2f o;
                float4x4 mvp = mul(UNITY_MATRIX_VP, modelMatrix);
                o.vertex = mul(mvp, v.vertex);

				float4 heightMap = tex2Dlod(_MainTex, float4(v.uv, 0, 0));

				o.vertex.y += heightMap.r * 0.6;

				o.uv = v.uv;
                return o;
            }			

            fixed4 frag (v2f i) : SV_Target
            {
				float intensityValue = tex2D(_MainTex, i.uv).r;
				return tex2D(_TexAltitude, float2(intensityValue, 0.5));
            }
            ENDCG
        }
    }
}
