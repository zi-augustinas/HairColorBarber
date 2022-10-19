# HairColorBarber
A VR game in Unity, where you can paint hair with different colours and modify their shape


Docummentations:

The project uses XR Interaaction toolkt for interactions: https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.2/manual/index.html

Hair Colouring system - it works with 3 different scripts two of which is just enabling the logic and responding to events in the game however the main one that is
behind the whole logic is "ColourSprayLogic". It is a non-monobehaviour script that has only one method 
"PixelColouring(Vector2 pixelUV, int size, float hardness, Color col, Texture2D tex)",

pixelUV - is the texture coordinates from 3D space transfered to UV Map

size - determines brush size

hardness - determines how much of a bloor effect we want on the edges of the brush

col - is the colour that we want to change the textures pixels to

Tex - is the texture that we want to paint on

This method uses GetPixels and SetPixels for the texture and changes it to desired colour.

Hair mesh sculpting system - similar to hair colouring it also has support scripts that just enable logic and listen and respond to events in the scene.
The main logic is held in one script which is responsible for growing the hair and trimming it.
The class name is "SculptingEffect" which has two methods inside 
"SculptExpand(Vector3[] vertices, Transform hitTransform, Vector3 hitVertexWorldPosition, MeshFilter meshFilter)" and
"SculptReduce(Vector3[] vertices, Transform hitTransform, Vector3 hitVertexWorldPosition, Vector3[] originalVertexPosition, MeshFilter meshFilter)"

verticies[] - array of verticies of an mesh that we want to modify

hitTransform - is the exact transform of a raycasthit. It is used for futher calculations in the method

hitVertexWorldPosition - its the closest vertex to a raycast hit point in worldPosition

meshFilter - meshFilter of the mesh that we want to change

[Exclusive for SculptReduce]
originalVertexPosition[] - it is an array of original vertices positions before any transformation

The method arguments should come from a raycasthit of a support script.


The project is also using basic Scriptable Object events, specifically a bool type event and an int type event for communicating between objects in the scene.
A lot of data in the project is serialized in the Inspector to use less processing power.

Everything else in the project are is standart Unity practices common among many projects



        
