Shader "LineBasedObject"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_ClipAxis("Clip Axis", Float) = 0
		_EffectAmount("Effect Amount", Float) = 10
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
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

			sampler2D _MainTex;
			float4 _MainTex_ST;

			float _ClipAxis;
			float _EffectAmount;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);

				float endFloat = 0;

				if (_ClipAxis == 0)
					endFloat = i.vertex.x;
				else if (_ClipAxis == 1)
					endFloat = i.vertex.y;

				//Renders this pixel if value inside is 0 or above.
				clip(1 - (endFloat % _EffectAmount));
				return col;
			}
			ENDCG
		}
	}
}