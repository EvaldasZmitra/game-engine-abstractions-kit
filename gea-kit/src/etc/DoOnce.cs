using System;

namespace GeaKit.Etc {
    public class DoOnce {
        private bool _canExecute = true;

        public void Do(Action action) {
            if (_canExecute) {
                _canExecute = false;
                action.Invoke();
            }
        }

        public void Reset() {
            _canExecute = true;
        }
    }
}