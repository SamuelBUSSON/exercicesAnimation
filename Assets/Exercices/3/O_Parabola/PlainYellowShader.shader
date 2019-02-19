// UNITY_SHADER_NO_UPGRADE

Shader "8TRD150/3_0_PlainYellowShader"
{
    Properties
    {
		_Oscill("Oscilation", Float) = 0.0
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
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };
            
            float4x4 modelMatrix;
			fixed _Oscill;

            v2f vert (appdata v)
            {
                v2f o;
                float4x4 mvp = mul(UNITY_MATRIX_VP, modelMatrix);
                o.vertex = mul(mvp, v.vertex);
				// o.vertex.y += sin(_Oscill * 2.2 + o.vertex.y); // pour faire osciller la courbe de maniere swag
				o.vertex.y += sin(_Oscill);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return fixed4(1, 1, 0, 1);
            }
            ENDCG
        }
    }
}
