using System.Collections.Generic;
using Mapsui.Animations;
using Mapsui.Utilities;

namespace Mapsui
{
    public interface IViewport : IReadOnlyViewport, IAnimatable
    {
        void SetCenter(double x, double y, long duration = 0, Easing? easing = default);
        void SetCenterAndResolution(double x, double y, double resolution, long duration = 0, Easing? easing = default);
        void SetCenter(MReadOnlyPoint center, long duration = 0, Easing? easing = default);
        void SetResolution(double resolution, long duration = 0, Easing? easing = default);
        void SetRotation(double rotation, long duration = 0, Easing? easing = default);
        void SetSize(double width, double height);
        void SetAnimations(List<AnimationEntry<Viewport>> animations);

        /// <summary>
        /// Moving the position of viewport to a new one
        /// </summary>
        /// <param name="position">Current center of touch</param>
        /// <param name="previousPosition">Previous center of touch</param>
        /// <param name="deltaResolution">Change of resolution for transformation (&lt;1: zoom out, >1: zoom in)</param>
        /// <param name="deltaRotation">Change of rotation</param>
        void Transform(MPoint position, MPoint previousPosition, double deltaResolution = 1, double deltaRotation = 0);
    }
}
