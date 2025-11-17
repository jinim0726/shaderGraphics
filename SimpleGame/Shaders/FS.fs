#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_UV;

uniform vec4 u_Color;

uniform sampler2D u_RGBTexture;

uniform float u_Time;

uniform vec2 u_TexelSize; 

const float PI = 3.141592

void Gausian()
{
vec4 totalColor = vec4(0.0);
    float dx = u_TexelSize.x;
    float dy = u_TexelSize.y;

    // 4x4 가우시안 유사 커널 가중치
    // [ 1  2  2  1 ]
    // [ 2  4  4  2 ]
    // [ 2  4  4  2 ]
    // [ 1  2  2  1 ]
    // 가중치 합계 = 36.0

    // 1행 (y = -1.5)
    totalColor += texture(u_RGBTexture, v_UV + vec2(-1.5*dx, -1.5*dy)) * 1.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2(-0.5*dx, -1.5*dy)) * 2.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2( 0.5*dx, -1.5*dy)) * 2.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2( 1.5*dx, -1.5*dy)) * 1.0;

    // 2행 (y = -0.5)
    totalColor += texture(u_RGBTexture, v_UV + vec2(-1.5*dx, -0.5*dy)) * 2.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2(-0.5*dx, -0.5*dy)) * 4.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2( 0.5*dx, -0.5*dy)) * 4.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2( 1.5*dx, -0.5*dy)) * 2.0;

    // 3행 (y = +0.5)
    totalColor += texture(u_RGBTexture, v_UV + vec2(-1.5*dx,  0.5*dy)) * 2.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2(-0.5*dx,  0.5*dy)) * 4.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2( 0.5*dx,  0.5*dy)) * 4.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2( 1.5*dx,  0.5*dy)) * 2.0;

    // 4행 (y = +1.5)
    totalColor += texture(u_RGBTexture, v_UV + vec2(-1.5*dx,  1.5*dy)) * 1.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2(-0.5*dx,  1.5*dy)) * 2.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2( 0.5*dx,  1.5*dy)) * 2.0;
    totalColor += texture(u_RGBTexture, v_UV + vec2( 1.5*dx,  1.5*dy)) * 1.0;

    // 가중치 합계(36.0)로 나누어 평균을 냅니다.
    FragColor = totalColor / 36.0;
}

void main()
{
    vec2 newUV = v_UV;
    float dx = 0.1 * sin(v_UV.y * 2 * c_PI * 4 + u_Time);
    float dy = 0.1 * sin(v_UV.x * 2 * c_PI * 4 + u_Time);
    newUV += vec2(dx, dy);
    vec4 sampleColor = texture(u_RGBTexture, newUV);
    FragColor = sampleColor;
}