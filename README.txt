This is a simple raytracer with phong shading, reflections and refractions.
This project was written in a day.

for this project i wrote my own vector math implementation, including ugly but fast Matrix4 multiplication. 
I ended up not using this due to time constraints.

This algorithm uses recursion for reflections and refractions.
This algorith uses less memory than previous algorithms I wrote because 
it only keeps track of the closest intersection while looping through objects.
I would still like to reduce the number of pointers beeing passed around. 
I wonder if an algorith not using subclasses for primitives and materials would be slightly faster.
Although such code would probably be way less pleasing.
Variable names in the code can be improved and are often shprtened for my short term convenience. 

fun features to implement on top of this code are
	- advanced camera movement using the 4x4 matrix code I wrote
	- triangles
	- meshes (imported from files)
	- sun lights
	- spot lights
	- HDRI skybox (imported from HDRI texture)
	- replacing the colors in materials with textures 
	- adding normal maps
	- adding mixed materials
	- adding a runtime object editor with file storage

more advanced projects would include
	- writing a raytracer for the gpu
	- writing a pathtracer 
	- writing a program that can switch between rasterisation and raytracing to compare results



