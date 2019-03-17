Shader "Custom/StencilFilter" {
	Properties {
		_MaskRef ("MaskRef", Range (0, 255)) = 1
		_Color ("Color", Color) = (1,1,1,1)
		[Enum(Equal,3,NotEqual,6)] _StencilTest ("Stencil Test", int) = 6
	}
	SubShader
	{
		Tags { "Queue"="Geometry"}
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
