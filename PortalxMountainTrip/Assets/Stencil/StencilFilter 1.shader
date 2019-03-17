Shader "Custom/StencilFilterX" {
	Properties {
		_MaskRef ("MaskRef", Range (0, 255)) = 1
		_Color ("Color", Color) = (1,1,1,1)
		[Enum(Equal,3,NotEqual,6)] _StencilTest ("Stencil Test", int) = 6
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue"="Transparent+2"}
		Color [_Color]
		
		Stencil
		{
			Ref [_MaskRef]
			Comp [_StencilTest]
		}

		Pass
		{
			
		}
	}
		
}
