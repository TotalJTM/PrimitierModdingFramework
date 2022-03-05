﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitierModdingFramework
{
	/// <summary>
	/// The event types for a PMFSystem
	/// </summary>
	public enum PMFEventType
	{
		ApplicationStart,
		ApplicationLateStart,
		ApplicationQuit,
		SceneLoad,
		Update,
		GUI,

		SystemEnabled,
		SystemDisabled,

	}

	/// <summary>
	/// Base class for all systems in pmf
	/// </summary>
	public abstract class PMFSystem
	{
		internal static List<PMFSystem> EnabledSystems = new List<PMFSystem>();
		/// <summary>
		/// The current mod
		/// </summary>
		protected static PrimitierMod Mod { get; private set; }

		
		private bool _IsStarted = false;


		internal static void Startup(PrimitierMod mod)
		{
			Mod = mod;
		}


		internal static void FireEventOnSystems(PMFEventType type)
		{
			foreach (var system in EnabledSystems)
			{
				system.FireEvent(type);
			}

		}

		/// <summary>
		/// Enables a system.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public static void EnableSystem<T>() where T : PMFSystem, new()
		{
			if (IsEnabled<T>())
				return;

			var newSystem = new T();
			newSystem.FireEvent(PMFEventType.SystemEnabled);
			EnabledSystems.Add(newSystem);
		}

		/// <summary>
		/// Disables a system
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public static void DisableSystem<T>() where T: PMFSystem, new()
		{
			foreach (var system in EnabledSystems)
			{
				if (system is T)
				{
					system.FireEvent(PMFEventType.SystemDisabled);
					EnabledSystems.Remove(system);
					return;
				}

			}
			

		}

		/// <summary>
		/// Returns true if the system is enabled
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static bool IsEnabled<T>() where T : PMFSystem
		{
			return EnabledSystems.Any((system) => { return system is T; }); ;
		}



		internal void FireEvent(PMFEventType type)
		{

			switch (type)
			{
				case PMFEventType.ApplicationStart:
					OnApplicationStart();
					if (!_IsStarted)
					{
						OnStart();
						_IsStarted = true;
					}
					break;

				case PMFEventType.ApplicationLateStart:
					OnApplicationLateStart();
					break;

				case PMFEventType.SceneLoad:
					OnSceneLoad();
					break;

				case PMFEventType.Update:
					OnUpdate();
					break;
				case PMFEventType.GUI:
					OnGUI();
					break;

				case PMFEventType.ApplicationQuit:
					OnApplicationQuit();
					break;


				case PMFEventType.SystemEnabled:
					OnSystemEnabled();
					if (!_IsStarted && Mod.IsApplicationStarted)
					{
						OnStart();
						_IsStarted = true;
					}
					break;
				case PMFEventType.SystemDisabled:
					OnSystemDisabled();
					break;

			}

		}

		public virtual void OnApplicationStart() { }
		public virtual void OnApplicationLateStart() { }

		public virtual void OnSceneLoad() { }

		public virtual void OnUpdate() { }
		public virtual void OnGUI() { }

		public virtual void OnApplicationQuit() { }


		public virtual void OnSystemDisabled() { }
		public virtual void OnSystemEnabled() { }

		public virtual void OnStart() { }



	}
}
