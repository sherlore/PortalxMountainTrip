Shader "Custom/PortalWindowZ"
{
	Properties
	{
		_MaskRef ("MaskRef", Range (0, 255)) = 1
	}
	SubShader
	{
		Tags { "Queue" = "Geometry-1" }
		ZWrite off
		ColorMask 0
		
		Stencil
		{
			Ref [_MaskRef]
			Comp Always
			Pass replace
		}

		Pass
		{
			
		}
	}
}
