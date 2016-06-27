﻿#version 330
 
// shader input
in vec2 uv;						// interpolated texture coordinates
in vec3 positie;				
in vec3 normal;					// interpolated normal
uniform sampler2D pixels;		// texture sampler
uniform vec4 ambientColor = vec4(0.1, 0.1, 0.1, 0.0);
const vec3 lPos = vec3(1.0,1.0,1.0);
const vec3 diffCol = vec3(0.0,0.5,0.5);
const vec3 specCol = vec3(1.0, 1.0, 1.0);
const float shine = 16.0;

uniform mat4 rotatie;

// shader output
out vec4 outputColor;

// fragment shader
void main()
{
  // outputColor = texture( pixels, uv,0.0 ) + 0.5f * vec4( normal.xyz, 1.0 );
	vec3 norm = normalize(normal);
	vec3 lDir = (rotatie * vec4(positie, 1.0) - vec4(lPos, 1.0)).xyz; 
		
	
	float lambert = max(dot(lDir, norm), 0.0);
	float specu = 0.0;
	if (lambert > 0.0)	{
		vec3 viewDir = normalize(-positie);

		vec3 reflDir = reflect(-lDir, norm);

		float specAng =  max(dot(reflDir, viewDir), 0.0);
		specu = pow(specAng ,shine/4.0);
	}
	vec4 texture =  texture( pixels, uv, 0.0);
	vec4 linColor = vec4(ambientColor + lambert*diffCol + specu* specCol + texture);
	vec4 gamCol = pow(linColor, vec4(1.0/2.2));
	outputColor =vec4(gamCol); 


	//gl_FragColor = vec4(ambientColor + lambert*diffCol + lambert*specCol + outputColor);
	//outputColor = outputColor * ambientColor;
	//uniform ambient
	//phong shader
}
