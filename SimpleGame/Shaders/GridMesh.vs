#version 330

in vec3 a_Position;

out vec4 v_Color;

uniform float u_Time;

const float c_PI = 3.141592;

void main()
{
	// a_Position.x : -0.5 ~ 0.5
	vec4 newPosition = vec4(a_Position, 1.0);

	float value = a_Position.x + 0.5; // 0 ~ 1

	newPosition.y = newPosition.y * (1 - value);

	float dX = 0;
	float dY = value * 0.5 * sin(2 * value * c_PI - u_Time * 5);
	float newColor = (sin(2 * value * c_PI - u_Time * 5) + 1) / 2;

	newPosition += vec4(dX, dY, 0, 0);

	gl_Position = newPosition;

	v_Color = vec4(newColor);
}
