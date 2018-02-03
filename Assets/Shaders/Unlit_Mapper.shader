Shader "Custom/Decoder"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "red" {}
		_RedTex ("Red Component", 2D) = "white" {}
		_GreenTex ("Green Component", 2D) = "white" {}
		_BlueTex ("Blue Component", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv0 : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
				float2 uv2 : TEXCOORD2;
				float2 uv3 : TEXCOORD3;
			};

			struct v2f
			{
				float2 uv0 : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
				float2 uv2 : TEXCOORD2;
				float2 uv3 : TEXCOORD3;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _RedTex;
			sampler2D _GreenTex;
			sampler2D _BlueTex;
			float4 _MainTex_ST;
			float4 _RedTex_ST;
			float4 _GreenTex_ST;
			float4 _BlueTex_ST;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv0 = TRANSFORM_TEX(v.uv0, _MainTex);
				o.uv1 = TRANSFORM_TEX(v.uv1, _RedTex);
				o.uv2 = TRANSFORM_TEX(v.uv2, _GreenTex);
				o.uv3 = TRANSFORM_TEX(v.uv3, _BlueTex);
				return o;
			}
			

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 main_color = tex2D(_MainTex, i.uv0);
				fixed4 component_red = tex2D(_RedTex, i.uv1);
				fixed4 component_green = tex2D(_GreenTex, i.uv2);
				fixed4 component_blue = tex2D(_BlueTex, i.uv3);

				fixed3 value = saturate(cross(main_color.rgb, 1.0));
				fixed4 color = fixed4(lerp(0, component_red.rgb, value.z), main_color.a);

				color.rgb += lerp(0, component_green.rgb, value.x);

				color.rgb += lerp(0, component_blue.rgb, value.y);

				return color;
			}
			ENDCG
		}
	}
}
