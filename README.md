# GodelTech.Business.AutoMapper

## Description
GodelTech.Business.AutoMapper is a library designed to integrate AutoMapper with GodelTech.Business, providing seamless mapping capabilities in the business layer of your .NET applications.

## Overview
`GodelTech.Business.AutoMapper` implements [GodelTech.Business](https://github.com/GodelTech/GodelTech.Business) `IBusinessMapper` interface using [AutoMapper](https://www.nuget.org/packages/AutoMapper) NuGet package. It allows to use mapping of `TSource` to `TDestination`.

```csharp
public class BusinessMapper : IBusinessMapper
{
    private readonly IMapper _mapper;

    public BusinessMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return _mapper.Map<TSource, TDestination>(source);
    }

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        return _mapper.Map(source, destination);
    }
}
```

## License
This project is licensed under the MIT License. See the LICENSE file for more details.