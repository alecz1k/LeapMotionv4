// Copyright 2017 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

Shader "Blocks/Basic" {
Properties {
  _Color ("Main Color", Color) = (1,1,1,1)
  _Shininess ("Shininess", Range (0.01, 1)) = 0.078125
  _SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 0)

}
    SubShader {
    Cull Back

    CGPROGRAM
    #pragma target 3.0
    #pragma surface surf StandardSpecular vertex:vert
    #pragma multi_compile __ TBT_LINEAR_TARGET

    #include "../../../Shaders/Include/Brush.cginc"

    struct Input {
      float4 color : Color;
    };

    fixed4 _Color;
    half _Shininess;

    void vert (inout appdata_full i /*, out Input o*/) {
      i.color = TbVertToNative(i.color);
    }

    void surf (Input IN, inout SurfaceOutputStandardSpecular o) {
      o.Albedo = _Color.rgb * IN.color.rgb;
      o.Smoothness = _Shininess;
      o.Specular = _SpecColor;
    }
      ENDCG
  }

  FallBack "Diffuse"
}
