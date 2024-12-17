namespace OTel;

public partial class Tags
{
    public partial class HttpTag : OTelTag
    {
        private class Registry
        {
            public partial class RequestTag : OTelTag
            {
                public partial class BodyTag
                {
                    public partial class SizeTag : OTelTag
                    {
                        
                    }

                    public SizeTag Size { get; } = new()
                    {
                        Id = "http.request.body.size",
                        Type = "int"
                    };
                }
                public BodyTag Body { get; } = new();

                public partial class HeaderTag : OTelTag { }

                public HeaderTag Header { get; } = new()
                {
                    Id = "http.request.header",
                    Type = "template[string[]]",
                };
            }
            
            public RequestTag Request { get; } = new();
        }
        public partial class RequestTag : OTelTag
        {
            public partial class BodyTag
            {
                public partial class SizeTag : OTelTag
                {
                    
                }

                public SizeTag Size { get; } = new()
                {
                    Id = "http.request.body.size",
                    Type = "int"
                };
            }
        }
    }
}
