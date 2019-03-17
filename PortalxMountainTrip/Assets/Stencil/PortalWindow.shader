Shader "Custom/PortalWindow"
{
	SubShader
	{
		Tags {"Queue" = "Geometry-1" }
		ZWrite off
		ColorMask 0
		
		Stencil
		{
			Ref 1
			Comp Always
			Pass replace
		}

		Pass 
		{

		}

	}
}
