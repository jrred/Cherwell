using Cherwell.Triangle.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cherwell.Triangle.Controllers
{
    /// <summary>
    /// TriangleController class
    /// </summary>
    [Route("api/triangle")]
    public class TriangleController : ControllerBase
    {
        #region Private Members

        private readonly ITriangleService _triangleService;

        #endregion Private Members

        /// <summary>
        /// TriangleController (constructor)
        /// </summary>
        public TriangleController([FromServices]ITriangleService triangleService)
        {
            _triangleService = triangleService;
        }

        /// <summary>
        /// GetTriangleVertices
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        [Route("[action]/{coordinates}")]
        [HttpGet]
        public ActionResult GetTriangleVertices(string coordinates)
        {
            var vertices = _triangleService.GetTriangleVertices(coordinates);

            return new ObjectResult(vertices);
        }

        [Route("[action]/{vertices}")]
        [HttpGet]
        public ActionResult GetTriangleCoordinates(string vertices)
        {
            var coordinates = _triangleService.GetTriangleCoordinates(vertices);

            return new ObjectResult(coordinates);
        }
    }
}
