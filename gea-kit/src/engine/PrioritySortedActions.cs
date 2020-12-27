
using System;
using System.Collections.Generic;

namespace GeaKit.Engine {
    public class PrioritySortedActions {
        private readonly SortedDictionary<int, List<Action<float>>> _actions = new();

        public void AddUpdate(
            Action<float> action,
            int priority = 0
        ) {
            if (_actions.ContainsKey(priority)) {
                _actions[priority].Add(action);
            } else {
                _actions.Add(
                    priority,
                    new List<Action<float>>() { action }
                );
            }
        }

        public void ExecuteAll(float deltaTime) {
            foreach (var actionList in _actions) {
                ExecuteActionList(actionList.Value, deltaTime);
            }
        }

        private static void ExecuteActionList(
            List<Action<float>> actionList,
            float deltaTime
        ) {
            foreach (var action in actionList) {
                action.Invoke(deltaTime);
            }
        }
    }
}