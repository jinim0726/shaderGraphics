#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_UV;

uniform sampler2D u_RGBTexture;
uniform float u_Time;

const float PI = 3.141592;
/*
void Test()
{
    vec2 newUV = v_UV;
    float dx = 0.1 * sin(v_UV.y * 2 * c_PI * 4 + u_Time);
    float dy = 0.1 * sin(v_UV.x * 2 * c_PI * 4 + u_Time);
    newUV += vec2(dx, dy);
    vec4 sampleColor = texture(u_RGBTexture, newUV);
    FragColor = sampleColor;
}

void Circles()
{
    vec2 newUV = v_UV;
    vec2 center = vec2(0.5, 0.5);
    vec4 newColor = vec4(0);

    float d = distance(newUV, center);
    
    float value = sin(d*4*c_PI*4 + u_Time);
    newColor = vec4(value);

    FragColor = newColor;
}
*/
void Q1()
{
    vec2 newUV = vec2(v_UV.x, v_UV.y);
    float x = fract(newUV.x*3);
    float y = floor(newUV.x * 3)/3 + v_UV.y/3;
    vec4 newColor = texture(u_RGBTexture, vec2(x,y));
    
    FragColor = newColor;
}

void main()
{
    Q1();
    //Circles();
}