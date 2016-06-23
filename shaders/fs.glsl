#version 330
 
// shader input
in vec2 uv;						// interpolated texture coordinates
in vec3 positie;				
in vec3 normal;					// interpolated normal
uniform sampler2D pixels;		// texture sampler
uniform vec3 ambientColor = vec3(0.3, 0.3, 0.3);
const vec3 lPos = vec3(30.0,1.0,2.0);
const vec3 diffCol = vec3(0.5,0.0,0.5);
const vec3 specCol = vec3(1.0, 1.0, 1.0);
const float shine = 16.0;


// shader output
out vec4 outputColor;

// fragment shader
void main()
{
    //outputColor = texture( pixels, uv ) + 0.0f * vec4( normal.xyz, 1 );
	vec3 norm = normalize(normal);
	vec3 lDir = normalize(lPos- positie);
		
	
	float lambert = max(dot(lDir, norm), 0.0);
	float specu = 0.0;
	if (lambert > 0.0)	{
		vec3 viewDir = normalize(-positie);

		vec3 reflDir = reflect(-lDir, norm);

		float specAng =  max(dot(reflDir, viewDir), 0.0);
		specu = pow(specAng, 4.0);
	}
	vec3 linColor = ambientColor + lambert*diffCol + specu* specCol;
	vec3 gamCol = pow(linColor, vec3(1.0/2.2));
	outputColor =vec4(gamCol, 1.0); 


	//gl_FragColor = vec4(ambientColor + lambert*diffCol + lambert*specCol, 1.0);
	//outputColor = outputColor * ambientColor;
	//uniform ambient
	//phong shader
}
