using AutoMapper;
using BooksApp.Business.Abstract;
using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using BooksApp.Shared.DTOs;
using BooksApp.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Business.Concrete
{
    public class PublisherManager : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public PublisherManager(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<Response<PublisherDto>> CreateAsync(PublisherCreateDto publisherCreateDto)
        {
            var newPublisher = _mapper.Map<Publisher>(publisherCreateDto);
            newPublisher.CreatedDate = DateTime.Now;
            await _publisherRepository.CreateAsync(newPublisher);
            var publisherDto = _mapper.Map<PublisherDto>(newPublisher);
            return Response<PublisherDto>.Success(publisherDto, 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var deletedPublisher = await _publisherRepository.GetByIdAsync(id);
            if (deletedPublisher == null)
            {
                return Response<NoContent>.Fail("Böyle bir yayınevi yok.", 401);
            }
            _publisherRepository.Delete(deletedPublisher);
            return Response<NoContent>.Success(203);
        }

        public async Task<Response<List<PublisherDto>>> GetAllAsync()
        {
            var publisherList = await _publisherRepository.GetAllAsync();
            var publisherDtoList = _mapper.Map<List<PublisherDto>>(publisherList);
            if (publisherList.Any())
            {
                return Response<List<PublisherDto>>.Success(publisherDtoList, 200);
            }
            return Response<List<PublisherDto>>.Fail("Hiç yayınevi yok", 401);
        }

        public async Task<Response<PublisherDto>> GetByIdAsync(int? id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            if (publisher != null)
            {
                return Response<PublisherDto>.Success(publisherDto, 200);
            }
            return Response<PublisherDto>.Fail("Böyle bir yayınevi yok", 401);
        }

        public async Task<Response<NoContent>> UpdateAsync(PublisherDto publisherDto)
        {
            var isThere = await _publisherRepository.AnyAsync(publisherDto.Id);
            if (isThere)
            {
                var publisher = _mapper.Map<Publisher>(publisherDto);
                publisher.ModifiedDate = DateTime.Now;
                _publisherRepository.Update(publisher);
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("Böyle bir yayınevi yok", 401);
        }
    }
}
