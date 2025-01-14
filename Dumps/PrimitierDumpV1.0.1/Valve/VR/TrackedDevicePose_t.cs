﻿/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 41: Unity.XR.OpenVR.dll - Assembly: Unity.XR.OpenVR, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 6242-6867

namespace Valve.VR
{
	public struct TrackedDevicePose_t // TypeDefIndex: 6769
	{
		// Fields
		public HmdMatrix34_t mDeviceToAbsoluteTracking; // 0x00
		public HmdVector3_t vVelocity; // 0x30
		public HmdVector3_t vAngularVelocity; // 0x3C
		public ETrackingResult eTrackingResult; // 0x48
		public bool bPoseIsValid; // 0x4C
		public bool bDeviceIsConnected; // 0x4D
	}
}
