namespace PostcodeNL {
    public class PostcodeResponse {
        /// <summary>
        /// Whether the address lookup was succesfull
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Street name in accordance with "BAG (Basisregistraties adressen en gebouwen)". 
        /// In capital and lowercase letters, including punctuation marks and accents. 
        /// This field is at most 80 characters in length. Filled with "Postbus" in case it is a range of PO boxes.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// House number of a perceel. In case of a Postbus match the house number will always be 0. Range: 0-99999
        /// </summary>
        public int HouseNumber { get; set; }

        /// <summary>
        /// Addition of the house number to uniquely define a location. These additions are officially recognized by the municipality. 
        /// Null if addition not found.
        /// </summary>
        public string HouseNumberAddition { get; set; }

        /// <summary>
        /// Four number neighborhoodcode (first part of a postcode). 
        /// Range: 1000-9999 plus two character lettercombination (second part of a postcode). Range: "AA"-"ZZ"
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Official city name in accordance with "BAG (Basisregistraties adressen en gebouwen)". In capital and lowercase letters, including punctuation marks and accents. 
        /// This field is at most 80 characters in length.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Municipality name in accordance with "BAG (Basisregistraties adressen en gebouwen)". In capital and lowercase letters, including punctuation marks and accents.
        /// This field is at most 80 characters in length. Examples: "Baarle-Nassau", "'s-Gravenhage".
        /// </summary>
        public string Municipality { get; set; }

        /// <summary>
        /// Official name of the province, correctly cased and with dashes where applicable.
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// X coordinate according to Dutch Rijksdriehoeksmeting "(EPSG) 28992 Amersfoort / RD New".
        /// Values range from 0 to 300000 meters.
        /// </summary>
        public int RdX { get; set; }

        /// <summary>
        /// Y coordinate according to Dutch Rijksdriehoeksmeting "(EPSG) 28992 Amersfoort / RD New".
        /// Values range from 300000 to 620000 meters.
        /// </summary>
        public int RdY { get; set; }

        /// <summary>
        /// Latitude of address.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of address.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Dutch term used in BAG: "nummeraanduiding id".
        /// </summary>
        public string BagNumberDesignationId { get; set; }

        /// <summary>
        /// Dutch term used in BAG: "adresseerbaar object id". Unique identification for objects which have 'building', 
        /// 'house boat site', or 'mobile home site' as addressType.
        /// </summary>
        public string BagAddressableObjectId { get; set; }

        /// <summary>
        /// Type of this address. See reference for possible values.
        /// </summary>
        public string AddressType { get; set; }

        /// <summary>
        /// List of all purposes (Dutch: "gebruiksdoelen"). See reference for possible values.
        /// </summary>
        public string[] Purposes { get; set; }

        /// <summary>
        /// Surface in square meters.
        /// </summary>
        public int SurfaceArea { get; set; }

        /// <summary>
        /// List of all house number additions having the postcode and houseNumber which was input.
        /// </summary>
        public string[] HouseNumberAdditions { get; set; }

        public override string ToString() {
            return IsSuccess ? string.Format("{0} {1}{2}, {3} {4}", Street, HouseNumber, HouseNumberAddition, Postcode, City) : "Not found";
        }
    }
}