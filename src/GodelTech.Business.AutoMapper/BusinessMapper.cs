using AutoMapper;

namespace GodelTech.Business.AutoMapper
{
    /// <summary>
    /// DataMapper class.
    /// </summary>
    /// <seealso cref="GodelTech.Business.IBusinessMapper" />
    public class BusinessMapper : IBusinessMapper
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessMapper"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public BusinessMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Execute a mapping from the source object to a new destination object.
        /// </summary>
        /// <typeparam name="TSource">Source type to use, regardless of the runtime type</typeparam>
        /// <typeparam name="TDestination">Destination type to create</typeparam>
        /// <param name="source">Source object to map from</param>
        /// <returns>Mapped destination object</returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Execute a mapping from the source object to the existing destination object.
        /// </summary>
        /// <typeparam name="TSource">Source type to use</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Source object to map from</param>
        /// <param name="destination">Destination object to map into</param>
        /// <returns>The mapped destination object, same instance as the <paramref name="destination" /> object</returns>
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}