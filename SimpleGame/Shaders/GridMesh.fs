#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_UV;
in vec4 v_Color;

uniform sampler2D u_RGBTexture;

uniform vec4 u_Color;

void main()
{
    vec4 sampleColor = texture(u_RGBTexture, newUV);
    FragColor = sampleColor;
}
