// UNITY_SHADER_NO_UPGRADE

Shader "8TRD150/3_0_PlainBlueShader"
{
    Properties
    {
		_MainTex("Texture", 2D) = "white" {}
		_TexDefor("Deformation", 2D) = "white" {}
		_Time("Time", Float) = 0.0 


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

			#include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
            };		

            struct v2f
            {
				float2 uv_MainTex : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            float4x4 modelMatrix;
			sampler2D _MainTex;
			float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                float4x4 mvp = mul(UNITY_MATRIX_VP, modelMatrix);
                o.vertex = mul(mvp, v.vertex);

				float2 coord = v.uv;
				coord.x = _Time*10 + coord.x;

				o.uv_MainTex = TRANSFORM_TEX(coord, _MainTex);
                return o;
            }			

            fixed4 frag (v2f i) : SV_Target
            {
				fixed4 col = tex2D(_MainTex, i.uv_MainTex);
				return col;
            }
            ENDCG
        }
    }
}
