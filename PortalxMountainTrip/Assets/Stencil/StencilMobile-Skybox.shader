// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

// Simplified Skybox shader. Differences from regular Skybox one:
// - no tint color

Shader "Custom/StencilSkybox" {
Properties {
	[Enum(Equal,3,NotEqual,6)] _StencilTest ("Stencil Test", int) = 6
    _FrontTex ("Front (+Z)", 2D) = "white" {}
    _BackTex ("Back (-Z)", 2D) = "white" {}
    _LeftTex ("Left (+X)", 2D) = "white" {}
    _RightTex ("Right (-X)", 2D) = "white" {}
    _UpTex ("Up (+Y)", 2D) = "white" {}
    _DownTex ("Down (-Y)", 2D) = "white" {}
}

SubShader {
    Tags { "Queue"="Background" "RenderType"="Background" "PreviewType"="Skybox" }
    Cull Off ZWrite Off Fog { Mode Off }
	
	Stencil
	{
		Ref 1
		Comp [_StencilTest]
	}
	
    Pass {
        SetTexture [_FrontTex] { combine texture }
    }
    Pass {
        SetTexture [_BackTex]  { combine texture }
    }
    Pass {
        SetTexture [_LeftTex]  { combine texture }
    }
    Pass {
        SetTexture [_RightTex] { combine texture }
    }
    Pass {
        SetTexture [_UpTex]    { combine texture }
    }
    Pass {
        SetTexture [_DownTex]  { combine texture }
    }
}
}
