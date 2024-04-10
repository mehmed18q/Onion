using Onion.Data.Site;
using Onion.Repository.DataTransfer;
using Onion.Service.Interfaces;

namespace Onion.Service.Implementation
{
	public class SliderService(IBaseRepository<Slider> sliderRepository) : ISliderService
	{
		private readonly IBaseRepository<Slider> _sliderRepository = sliderRepository;

		public void InsertSlider(Slider slider)
		{
			_sliderRepository.Insert(slider);
		}

		public List<Slider> GetAllSliders()
		{
			return _sliderRepository.Get(null).ToList();
		}

		public Slider? GetSliderById(int sliderId)
		{
			return _sliderRepository.GetById(sliderId);
		}

		public List<Slider> GetActivatedSliders()
		{
			return _sliderRepository.Get(s => s.IsActive).ToList();
		}

		public void EditSlider(Slider slider)
		{
			_sliderRepository.Update(slider);
		}

		public void Dispose()
		{
			_sliderRepository.Dispose();
		}

	}

}
