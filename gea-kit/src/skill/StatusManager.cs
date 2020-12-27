using System.Collections.Generic;
using GameMakingKit.Interfaces;

namespace GeaKit.Skill {
    public class StatusManager {
        private readonly Dictionary<StatusType, List<Status>> _statusDict = new();
        private readonly IEngineHook _engineHook;

        public StatusManager(IEngineHook engineHook) {
            _engineHook = engineHook;
        }

        public bool HasStatus(StatusType type) {
            return _statusDict.ContainsKey(type) &&
                    _statusDict[type].Count > 0;
        }

        public void AddStatus(Status status) {
            if (!_statusDict.ContainsKey(status.Type)) {
                _statusDict.Add(status.Type, new List<Status>());
            }

            _statusDict[status.Type].Add(status);
            status.Cooldown.StartAndDoWhenCompleted(() => {
                _statusDict[status.Type].Remove(status);
            });
        }
    }
}