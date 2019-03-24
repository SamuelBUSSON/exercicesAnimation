// UNITY_SHADER_NO_UPGRADE

Shader "8TRD150/ShaderDifform"
{
    Properties
    {
		_MainTex("Texture", 2D) = "white" {}
		_TexDeform("Deformation", 2D) = "white" {}
		_TexIntensity("Intensite", 2D) = "white" {}
		_Scale("Scale", Float) = 0.0


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
				float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            float4x4 modelMatrix;

			sampler2D _MainTex;
			sampler2D _TexDeform;
			sampler2D _TexIntensity;

			float4 _MainTex_ST;

			float time;
			float _Scale;


            v2f vert (appdata v)
            {
                v2f o;
                float4x4 mvp = mul(UNITY_MATRIX_VP, modelMatrix);
                o.vertex = mul(mvp, v.vertex);

				o.uv = v.uv;
                return o;
            }			

            fixed4 frag (v2f i) : SV_Target
            {
				
				float2 coord2;
				coord2.x = time;
				coord2.y = 0.5;
				float intensityValue = tex2D(_TexIntensity, coord2).r * _Scale;

				float2 coordDeform = i.uv + float2(sin(time), 0.0);

				float2 deformVector = tex2D(_TexDeform, coordDeform).xy;
				deformVector = deformVector * intensityValue;

				float2 coordText = i.uv + deformVector;
				
				return tex2D(_MainTex, coordText);
            }
            ENDCG
        }
    }
}
