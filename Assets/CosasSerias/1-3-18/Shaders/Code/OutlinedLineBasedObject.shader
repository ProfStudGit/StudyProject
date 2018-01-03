Shader "Unlit/Outline"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}

		_OutlineEnabled("Enabled", Float) = 0
		_OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
		_OutlineWidth("Outline Width", Range(0.01, 5)) = 0

		_ClipAxis("Clip Axis", Int) = 0
		_EffectAmount("Effect Amount", Float) = 10
	}

	SubShader
	{
			Tags{ "RenderType" = "Opaque" }
			LOD 100

			//Outline rendering.
			Pass
			{
				ZWrite Off

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
					float4 vertex : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;

				float _OutlineEnabled;
				float _OutlineWidth;
				float4 _OutlineColor;

				v2f vert(appdata v)
				{
					if (_OutlineEnabled > 1)
						_OutlineEnabled = 1;

					v.vertex.xyz *= (1 + _OutlineWidth) * _OutlineEnabled;

					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);

					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					return _OutlineColor;
				}

				ENDCG
			}

			//Normal rendering.
			Pass
			{
				ZWrite On

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
					float4 vertex : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;

				int _ClipAxis;
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