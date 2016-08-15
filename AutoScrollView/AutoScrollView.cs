/*
 * Copyright 2016  173210 <root.3.173210@live.com>
 *
 * This Source Code Form is subject to the terms of the Mozilla Public License,
 * v. 2.0. If a copy of the MPL was not distributed with this file, You can
 * obtain one at https://mozilla.org/MPL/2.0/.
 */

using Xamarin.Forms;

namespace AutoScrollView
{
    public class AutoScrollView : ScrollView
    {
		public static readonly BindableProperty AutoOrientationProperty = BindableProperty.Create("Orientation", typeof(ScrollOrientation), typeof(ScrollView), ScrollOrientation.Vertical);

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            var oldContentSize = ContentSize;
            var oldX = ScrollX;
            var oldY = ScrollY;

            base.LayoutChildren(x, y, width, height);

            switch (AutoOrientation) {
                case ScrollOrientation.Horizontal:
                    ScrollToAsync(ContentSize.Width, 0, false);
                    break;

                case ScrollOrientation.Vertical:
                    ScrollToAsync(0, ContentSize.Height, false);
                    break;

                case ScrollOrientation.Both:
                    var newX = oldX;
                    var newY = oldY;

                    if (oldContentSize.Width < ContentSize.Width)
                        newX = ContentSize.Width;

                    if (oldContentSize.Height < ContentSize.Height)
                        newY = ContentSize.Height;

                    ScrollToAsync(newX, newY, false);
                    break;
            }
        }

		public ScrollOrientation AutoOrientation
		{
			get { return (ScrollOrientation)GetValue(AutoOrientationProperty); }
			set { SetValue(AutoOrientationProperty, value); }
		}
    }
}
