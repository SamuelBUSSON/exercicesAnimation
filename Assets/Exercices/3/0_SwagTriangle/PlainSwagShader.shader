// UNITY_SHADER_NO_UPGRADE

Shader "8TRD150/3_0_PlainSwagShader"
{
    Properties
    {
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata
            {
                float4 vertex : POSITION;
				float4 vertColors : COLOR;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
				float4 vertColors : COLOR;
            };
            
            float4x4 modelMatrix;

            v2f vert (appdata v)
            {
                v2f o;
                float4x4 mvp = mul(UNITY_MATRIX_VP, modelMatrix);
                o.vertex = mul(mvp, v.vertex);
				o.vertColors = v.vertColors;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
			{
				return fixed4(i.vertColors[0], i.vertColors[1], i.vertColors[2], i.vertColors[3]);
            }
            ENDCG
        }
    }
}
