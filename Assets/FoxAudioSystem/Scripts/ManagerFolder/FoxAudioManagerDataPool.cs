﻿using System.Collections.Generic;
using System.Linq;
using FoxAudioSystem.Scripts.CoreFolder;
using FoxAudioSystem.Scripts.PlayersFolder;

namespace FoxAudioSystem.Scripts.ManagerFolder
{

	public class FoxAudioManagerDataPool
	{
		private readonly Dictionary<string, List<ControlledAudioResource>> _controlledPlayingAudio;

		public FoxAudioManagerDataPool()
		{
			_controlledPlayingAudio = new Dictionary<string, List<ControlledAudioResource>>();
		}

		public void Add(ControlledAudioResource resource)
		{
			if(!_controlledPlayingAudio.ContainsKey(resource.Key))
				_controlledPlayingAudio.Add(resource.Key, new List<ControlledAudioResource>(1));

			_controlledPlayingAudio[resource.Key].Add(resource);
		}

		public bool TryGetControlledAudioResource(ControlledAudioResource resource)
		{
			if(resource == null)
				return false;

			bool result = TryGetControlledAudioResource(resource.Key, resource.ID, out ControlledAudioResource getResource);

			return result;
		}

		public bool TryGetControlledAudioResource(string key, string id, out ControlledAudioResource resource)
		{
			resource = null;

			if(!_controlledPlayingAudio.ContainsKey(key) || _controlledPlayingAudio[key].Count == 0)
				return false;

			resource = _controlledPlayingAudio[key].FirstOrDefault(p => p.ID == id);

			if(resource != null)
				_controlledPlayingAudio[key].Remove(resource);

			return resource != null;
		}

		public List<ControlledAudioResource> GetAll()
		{
			List<ControlledAudioResource> controlled = new List<ControlledAudioResource>();

			foreach(KeyValuePair<string, List<ControlledAudioResource>> cont in _controlledPlayingAudio)
				controlled.AddRange(cont.Value);

			return controlled;
		}

		public bool Get(IAudioPlayer audioPlayer) =>
			TryGetControlledAudioResource(audioPlayer.Name, audioPlayer.ID, out ControlledAudioResource resource);
	}
}