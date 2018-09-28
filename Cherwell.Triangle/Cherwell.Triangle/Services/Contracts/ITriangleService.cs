using Cherwell.Triangle.Models;

namespace Cherwell.Triangle.Services.Contracts
{
    public interface ITriangleService
    {
        VertexContainer GetTriangleVertices(string coordinates);

        CoordinatesContainer GetTriangleCoordinates(string vertices);
    }
}
