#version 330

layout(location=0) out vec4 FragColor;

int vec2 v_UV;

uniform sampler2D u_RGBTexture;

uniform vec4 u_Color;

void main()
{
	FragColor = vec4(u_Color.r, u_Color.g, u_Color.b, u_Color.a);
}
