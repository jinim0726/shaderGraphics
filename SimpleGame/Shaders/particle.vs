#version 330

in vec3 a_Position;
in float a_Radius;
in vec4 a_Color;
in float a_sTime;
in float a_LifeTime;
in vec3 a_Vel;
in float a_Mass;

out vec4 v_Color;

uniform float u_Time;
uniform vec3 u_Force;

const float c_PI = 3.141592;
const vec2 c_G = vec2(0, -9.8);

void main()
{
	float lifeTime = a_LifeTime;
	float newAlpha = 1.0;
	vec4 newPosition = vec4(a_Position, 1);
	float newTime = u_Time - a_sTime;
	if(newTime > 0)
	{
		float t = fract(newTime / lifeTime) * lifeTime; // t : 0 ~ lifeTime
		float tt = t * t;
		float forceX = u_Force.x + c_G.x * a_Mass;
		float forceY = u_Force.y + c_G.y * a_Mass;

		float aX = forceX / a_Mass;
		float aY = forceY / a_Mass;

		float x = a_Vel.x * t + 0.5 * aX * tt;
		float y = a_Vel.y * t + 0.5 * aY * tt;
		newPosition.xy += vec2(x, y);
		newAlpha = 1.0 - (t / lifeTime); // 1 ~ 0
	}
	else
	{
		newPosition.xy = vec2(-100000, 0);
	}

	gl_Position = newPosition;
	v_Color = vec4(a_Color.rgb, newAlpha);
}
