﻿// Copyright (C) 2015  James Liu
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
using System.Collections.Generic;
using UnityUtilLib;
using Vexe.Runtime.Types;

namespace Danmaku2D {

	public abstract class DanmakuTriggerReciever : BetterBehaviour, IDanmakuNode {

		[SerializeField]
		private List<DanmakuTrigger> triggers;

		public void Awake () {
			for(int i = 0; i < triggers.Count; i++) {
				if(triggers[i] != null) {
					triggers[i].triggerCallback += Trigger;
				}
			}
		}

		public void OnDestroy() {
			for(int i = 0; i < triggers.Count; i++) {
				if(triggers[i] != null) {
					triggers[i].triggerCallback -= Trigger;
				}
			}
		}

		public abstract void Trigger ();
	}

	[AddComponentMenu("Danmaku 2D/Danmaku Trigger")]
	public class DanmakuTrigger : CachedObject, IDanmakuNode {

		public delegate void TriggerCallback ();
		
		internal TriggerCallback triggerCallback;
		
		public void Trigger() {
			if(triggerCallback != null)
				triggerCallback();
		}

	}

}
