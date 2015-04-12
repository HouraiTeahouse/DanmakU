// Copyright (C) 2015  James Liu
//	
//	This program is free software: you can redistribute it and/or modify
//	it under the terms of the GNU General Public License as published by
//	the Free Software Foundation, either version 3 of the License, or
//	(at your option) any later version.
//		
//	This program is distributed in the hope that it will be useful,
//	but WITHOUT ANY WARRANTY; without even the implied warranty of
//	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//	GNU General Public License for more details.
//			
//	You should have received a copy of the GNU General Public License
//	along with this program.  If not, see <http://www.gnu.org/licenses/>

using UnityEngine;

namespace Danmaku2D.DanmakuControllers {

	[System.Serializable]
	public class AnimationCurveController : IDanmakuController {

		[SerializeField]
		private AnimationCurve velocityCurve;

		#region IDanmakuController implementation
		public virtual void UpdateDanmaku (Danmaku danmaku, float dt) {
			float velocity = velocityCurve.Evaluate (danmaku.Time);
			if (velocity != 0)
				danmaku.Position += danmaku.Direction * velocity * dt;
		}
		#endregion
	}

	namespace Wrapper {
		
		[AddComponentMenu("Danmaku 2D/Controllers/Animation Curve Controller")]
		internal class AnimationCurveController : ControllerWrapperBehavior<AnimationCurveController> {
		}

	}
}

