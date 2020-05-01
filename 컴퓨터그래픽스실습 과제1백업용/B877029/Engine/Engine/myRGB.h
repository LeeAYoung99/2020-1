
#ifndef _MYRGB_H_
#define _MYRGB_H_


#include "d3dclass.h"



class MyRGB
{
public:
	MyRGB();
	MyRGB(const MyRGB&);
	~MyRGB();


	bool RedFrame();
	bool GreenFrame();
	bool BlueFrame();

private:
	bool Render();

private:
	D3DClass* m_D3D;
};

#endif#pragma once
