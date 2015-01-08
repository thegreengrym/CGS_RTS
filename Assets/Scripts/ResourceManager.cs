using UnityEngine;
using System.Collections;



namespace RTS {
	public static class ResourceManager {
		public static int ScrollWidth { get { return 15; } }
		public static float ScrollSpeed { get { return 5; } }
		public static float ZoomSpeed { get { return 5; } }
		public static float RotateAmount { get { return 10; } }
		public static float RotateSpeed { get { return 100; } }
		public static float MinCameraHeight { get { return 5; } }
		public static float MaxCameraHeight { get { return 20; } }
		public static float MaxCameraX { get { return 50; } }
		public static float MaxCameraY { get { return 50; } }
	}
}
