Shader "Hidden/Circle"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Radius ("Radisu", Float) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;
			float _Radius;
			float4 _MainTex_TexelSize;

			fixed4 frag (v2f_img i) : SV_Target
			{
				// get the source color of screen
				fixed4 col = tex2D(_MainTex, i.uv);
				// center pixel
				half2 center = _MainTex_TexelSize.zw / 2;
				half2 pixelPos = i.uv * _MainTex_TexelSize.zw;
				// distance to the center by pixel
				half dist = distance(center, pixelPos);
				// get the radius by pixels
				half radius = _Radius * _MainTex_TexelSize.z;

				// 方法一 如果像素在半径内 输出原图；如果在外，输出黑色
				// 这样很简单，但是很粗暴，边缘全是锯齿
				// if (dist < radius) return col; else return 0;
				// 方法一结束

				// 方法二 纯数值算法，避免if语句带来的边缘锯齿
				float f = clamp(radius - dist, 0, 1);
				return col * f;
				// 方法二 结束
			}
			ENDCG
		}
	}
}
