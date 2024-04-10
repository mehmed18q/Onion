using Microsoft.AspNetCore.Mvc;
using Onion.Service.DTO.Song;
using Onion.Web.UOW;

namespace Onion.Web.Controllers
{
    public class SongController : Controller
    {
        public class SongController : Controller
        {
            private readonly IUnitOfWork unitOfWork;

            public SongController(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            [Route("SingleSong/{songId:Int}/{songName}", Name = "SingleSong")]
            public ActionResult SingleSong(int songId, string songName)
            {
                SingleSongDTO? song = unitOfWork.SongService.GetSingleSong(songId);

                if (song == null)
                {
                    return HttpNotFound();
                }

                // todo : visit song

                if (!unitOfWork.SongService.HasUserVisitedSong(songId, UserManager.GetUserIP()))
                {
                    unitOfWork.SongService.AddVisitForSong(songId, UserManager.GetUserIP());
                    unitOfWork.save();
                }

                return View(song);
            }

            public ActionResult Index(AllSongsDTO filter)
            {
                filter.TakeEntity = 18;

                AllSongsDTO songs = unitOfWork.SongService.GetAllSongs(filter);

                return View(songs);
            }

            public ActionResult LikeSong(int songId)
            {
                if (unitOfWork.SongService.IsExistSongById(songId))
                {
                    if (unitOfWork.SongService.HasUserLikedSong(songId, UserManager.GetUserIP()))
                    {
                        unitOfWork.SongService.DisLikeSong(songId, UserManager.GetUserIP());
                        unitOfWork.save();
                        return Json(new { status = "DisLike" }, JsonRequestBehavior.AllowGet);
                    }

                    unitOfWork.SongService.LikeSong(songId, UserManager.GetUserIP());
                    unitOfWork.save();
                    return Json(new { status = "Like" }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
