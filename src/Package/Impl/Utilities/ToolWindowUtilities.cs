﻿using Microsoft.VisualStudio.R.Packages.R;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace Microsoft.VisualStudio.R.Package.Utilities {
    public static class ToolWindowUtilities {
        public static T FindWindowPane<T>(int id) where T : class {
            return RPackage.Current.FindWindowPane(typeof(T), id, true) as T;
        }

        public static T ShowWindowPane<T>(int id, bool focus) where T : ToolWindowPane {
            T window = RPackage.Current.FindWindowPane(typeof(T), id, true) as T;
            if (window != null) {
                var frame = window.Frame as IVsWindowFrame;
                if (frame != null) {
                    ErrorHandler.ThrowOnFailure(frame.Show());
                }
                if (focus) {
                    var content = window.Content as System.Windows.UIElement;
                    if (content != null) {
                        content.Focus();
                    }
                }
            }
            return window;
        }
    }
}
