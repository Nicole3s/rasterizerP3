#version 330
 
// shader input
in vec2 vUV;				// vertex uv coordinate
in vec3 vNormal;			// untransformed vertex normal
in vec3 vPosition;			// untransformed vertex position

// shader output
out vec3 normal;			// transformed vertex normal
out vec2 uv;		
out vec3 positie;		
uniform mat4 transform;
 
// vertex shader
void main()
{
	// transform vertex using supplied matrix
	gl_Position = transform * vec4(vPosition, 1.0);

	// forward normal and uv coordinate; will be interpolated over triangle
	normal = vec3(transform * vec4( vNormal, 1.0f ));
	positie = vPosition;
	uv = vUV;
	
}



