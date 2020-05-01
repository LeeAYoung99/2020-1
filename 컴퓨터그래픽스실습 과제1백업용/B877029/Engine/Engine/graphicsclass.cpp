////////////////////////////////////////////////////////////////////////////////
// Filename: graphicsclass.cpp
////////////////////////////////////////////////////////////////////////////////
#include "graphicsclass.h"


using namespace std;


GraphicsClass::GraphicsClass()
{
	m_D3D = 0;
}


GraphicsClass::GraphicsClass(const GraphicsClass& other)
{
	m_Camera = 0;
	m_Model = 0;
	m_ColorShader = 0;
	red = 0;
	blue = 0;
	green = 0;
	alpha = 1.0f;
}


GraphicsClass::~GraphicsClass()
{
}


bool GraphicsClass::Initialize(int screenWidth, int screenHeight, HWND hwnd)
{
	bool result;


	// Create the Direct3D object.
	m_D3D = new D3DClass;


	if(!m_D3D)
	{
		return false;
	}

	// Initialize the Direct3D object.
	result = m_D3D->Initialize(screenWidth, screenHeight, VSYNC_ENABLED, hwnd, FULL_SCREEN, SCREEN_DEPTH, SCREEN_NEAR);

	// Create the camera object.
	m_Camera = new CameraClass;
	if (!m_Camera)
	{
		return false;
	}
	// Set the initial position of the camera.
	m_Camera->SetPosition(0.0f, 0.0f, -10.0f);
	// Create the model object.
	m_Model = new ModelClass;
	if (!m_Model)
	{
		return false;
	}
	// Initialize the model object.
	result = m_Model->Initialize(m_D3D->GetDevice());

	if (!result)
	{
		MessageBox(hwnd, L"Could not initialize the model object.", L"Error", MB_OK);
		return false;
	}
	// Create the color shader object.
	m_ColorShader = new ColorShaderClass;
	if (!m_ColorShader)
	{
		return false;
	}
	// Initialize the color shader object.
	result = m_ColorShader->Initialize(m_D3D->GetDevice(), hwnd);
	if (!result)
	{
		MessageBox(hwnd, L"Could not initialize the color shader object.", L"Error", MB_OK);
		return false;
	}

	if(!result)
	{
		MessageBox(hwnd, L"Could not initialize Direct3D.", L"Error", MB_OK);
		return false;
	}


	///////
	//D3DClass d3dclass;
	string videoCardInfo = "";
	int memoryInfo = 0;
	ofstream fout("VideoInfo.txt");
	m_D3D->GetVideoCardInfo(videoCardInfo, memoryInfo);//
	fout << videoCardInfo << endl;
	fout << memoryInfo << endl;
	fout.close();
	///////:D

	return true;
}


void GraphicsClass::Shutdown()
{
	// Release the color shader object.
	if (m_ColorShader)
	{
		m_ColorShader->Shutdown();
		delete m_ColorShader;
		m_ColorShader = 0;
	}
	// Release the model object.
	if (m_Model)
	{
		m_Model->Shutdown();
		delete m_Model;
		m_Model = 0;
	}
	
	// Release the camera object.
	if (m_Camera)
	{
		delete m_Camera;
		m_Camera = 0;
	}

	// Release the D3D object.
	if(m_D3D)
	{
		m_D3D->Shutdown();
		delete m_D3D;
		m_D3D = 0;
	}

	return;
}


bool GraphicsClass::Frame()
{
	bool result;


	// Render the graphics scene.
	result = Render();
	if(!result)
	{
		return false;
	}

	return true;
}


bool GraphicsClass::Render()
{
	
	D3DXMATRIX viewMatrix, projectionMatrix, worldMatrix;
	bool result;
	// Clear the buffers to begin the scene.
	
	m_D3D->BeginScene(red, green, blue, alpha);
	// Generate the view matrix based on the camera's position.
	m_Camera->Render();
	// Get the world, view, and projection matrices from the camera and d3d objects.
	m_Camera->GetViewMatrix(viewMatrix);
	m_D3D->GetWorldMatrix(worldMatrix);
	m_D3D->GetProjectionMatrix(projectionMatrix);

	// 매 프레임마다 회전값을 갱신합니다.
	static float rotation = 0.0f;
	rotation += (float)D3DX_PI * 0.005f; 
	if(rotation > 360.0f) 
	{ 
		rotation -= 360.0f; 
	} 
	D3DXMatrixRotationY(&worldMatrix, rotation);


	// Put the model vertex and index buffers on the graphics pipeline to prepare them for drawing
	m_Model->Render(m_D3D->GetDeviceContext());
	// Render the model using the color shader.
	result = m_ColorShader->Render(m_D3D->GetDeviceContext(), m_Model->GetIndexCount(), worldMatrix,
		viewMatrix, projectionMatrix);
	if (!result)
	{
		return false;
	}

	// Present the rendered scene to the screen.
	m_D3D->EndScene();

	return true;
}




void GraphicsClass::ChangeFillMode(int fillMode)
{

	m_D3D->ChangeFillMode(fillMode);
	return;


}

void GraphicsClass::SetRotation(float x, float y, float z)
{
	m_Camera->SetRotation(x, y, z);
	return;
}

void GraphicsClass::SetPosition(float x, float y, float z)
{
	m_Camera->SetPosition(x, y, z);
	return;
}

void GraphicsClass::SetBGColor(float r, float g, float b, float a) //요이
{
	red = r;
	green = g;
	blue = b;
	alpha = a;
}