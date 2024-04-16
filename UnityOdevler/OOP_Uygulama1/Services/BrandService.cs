using OOP_Uygulama1.Exceptions;
using OOP_Uygulama1.Models;
using OOP_Uygulama1.Repository;
using System.Threading.Channels;
using System.Collections.Generic;

namespace OOP_Uygulama1.Services;

public class BrandService
{
    
    private BrandRepository _brandRepository;

    public BrandService()
    {
        _brandRepository = new BrandRepository();
    }

    public void Add(Brand brand)
    {
        try
        {
            if (string.IsNullOrEmpty(brand.Name))
            {
                throw new BusinessException("Marka adı boş olamaz.");
            }

            _brandRepository.Add(brand);
        }
        catch (BusinessException ex)
        {
            Console.WriteLine("İş istisnası oluştu:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Beklenmeyen bir hata oluştu:");
            Console.WriteLine(ex.Message);
        }
    }

    public void GetAll()
    {
        List<Brand> brands = _brandRepository.GetAll();
        brands.ForEach(x => Console.WriteLine(x));
    }

    public void Delete(int id)
    {
        _brandRepository.Delete(id);
    }

    public Brand GetById(int id)
    {
        return _brandRepository.GetById(id);
    }
    

}
