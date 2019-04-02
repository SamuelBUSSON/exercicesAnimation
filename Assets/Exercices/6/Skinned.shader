﻿// UNITY_SHADER_NO_UPGRADE

Shader "8TRD150/6_Skinned"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
            
            #define MAX_BONES 5
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float2 bones : TEXCOORD1;
                float2 boneWeight: TEXCOORD2;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            float4x4 _Bones[MAX_BONES];
            
            v2f vert (appdata v)
            {
                v2f o;

				float4x4 bone = _Bones[(int)v.bones.x] * v.boneWeight.x;
				float4x4 bone2 = _Bones[(int)v.bones.y] * v.boneWeight.y;
				float4x4 mat = mul(UNITY_MATRIX_MVP, (bone + bone2));

                o.vertex = mul(mat, v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}
