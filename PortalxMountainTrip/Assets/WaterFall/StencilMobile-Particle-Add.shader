// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

// Simplified Additive Particle shader. Differences from regular Additive Particle one:
// - no Tint color
// - no Smooth particle support
// - no AlphaTest
// - no ColorMask

Shader "Custom/Particles/StencilAdditive" {
Properties {
    _MainTex ("Particle Texture", 2D) = "white" {}
	_MaskRef ("MaskRef", Range (0, 255)) = 1
	[Enum(Equal,3,NotEqual,6)] _StencilTest ("Stencil Test", int) = 6
}

Category {
    Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
    Blend SrcAlpha One
    Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }

    BindChannels {
        Bind "Color", color
        Bind "Vertex", vertex
        Bind "TexCoord", texcoord
    }

    SubShader {
	
		
		Stencil
		{
			Ref [_MaskRef]
			Comp [_StencilTest]
		}
	
        Pass {
            SetTexture [_MainTex] {
                combine texture * primary
            }
        }
    }
}
}
