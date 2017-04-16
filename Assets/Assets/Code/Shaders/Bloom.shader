Shader "Hidden/Bloom" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_BloomThresh ("Bloom Threshhold", Range(0.0,1.0)) = 0.5
	}
	SubShader {
		Cull Off ZWrite Off ZTest Always

		Pass {
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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float _BloomThresh;

			float4 frag (v2f IN) : SV_Target
			{
				float4 tex = tex2D(_MainTex, IN.uv);

				float4 c = tex;
				c += 1.1*max(sign(tex.r+tex.g+tex.b - _BloomThresh), 0.0f);
				return c;
			}
			ENDCG
		}
	}
}
