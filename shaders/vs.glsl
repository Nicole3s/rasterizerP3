#version 330
 
// shader input
in vec2 vUV;				// vertex uv coordinate (van texture)
in vec3 vNormal;			// untransformed vertex normal
in vec3 vPosition;			// untransformed vertex position
uniform mat4 transform, rotatie, camera;
// shader output
out vec3 normal;			// transformed vertex normal
out vec2 uv;		
out vec3 positie;		
out vec3 pos;
 
// vertex shader
void main()
{
	// transform vertex using supplied matrix
	gl_Position = camera * vec4(vPosition, 1.0);

	// forward normal and uv coordinate; will be interpolated over triangle
	normal =  (transform  * vec4( vNormal, 1.0f )).xyz;
	pos = (camera *(vec4(vPosition, 1.0))).xyz;
	
	
	uv = vUV;
	
}



