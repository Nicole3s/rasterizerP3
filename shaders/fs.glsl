#version 330
 
// shader input
in vec2 uv;						// interpolated texture coordinates
in vec4 normal;					// interpolated normal
uniform sampler2D pixels;		// texture sampler
uniform vec3 ambientColor = vec3(0.1, 0.1, 0.1);

// shader output
out vec4 outputColor;

// fragment shader
void main()
{
    outputColor = texture( pixels, uv ) + 0.0f * vec4( normal.xyz, 1 );
	outputColor = outputColor + ambientColor;
	//uniform ambient
	//phong shader
}