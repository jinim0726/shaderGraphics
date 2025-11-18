#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_UV;
in vec4 v_Color;

uniform sampler2D u_RGBTexture;

uniform vec4 u_Color;
/*
void Flag()
{
    vec2 newUV = vec2(v_UV.x, 1-v_UV.y-0.5);
    vec4 newColor = vec4(0)

    float width = 0.2 * (1-newUV.x);
    float sinValue = newUV.x * 0.2 * sin(v_UV.x*2*c_PI);

    if(v_UV.y<sinValue+width && newUV.y>sinValue-width) {
        newColor vec4(1);
    }
    else
    {
        discard;
    }
    FragColor = newColor;
}
*/
void main()
{
    //Flag();
}
