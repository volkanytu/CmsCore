namespace CmsCore.Library.Constants.SqlQueries
{
    public class CreateEntitiesTableQuery : BaseQuery
    {
        public override string SqlQuery => @"CREATE TABLE cms_entity (
                                                Id INT NOT NULL AUTO_INCREMENT,
                                                Name VARCHAR(45) NOT NULL,
                                                Title VARCHAR(45) NOT NULL,
                                                PluralTitle VARCHAR(45) NOT NULL,
                                                Description BIT NOT NULL DEFAULT 1,
                                            PRIMARY KEY (Id))";
    }

    public class CreateEntityTableQuery : BaseQuery
    {
        private readonly string _entityName;
        private readonly string _pkColumnName;
        private readonly string _tableColumnsQueries;

        public CreateEntityTableQuery(string entityName, string pkColumnName, string tableColumnsQueries)
        {
            _entityName = entityName;
            _pkColumnName = pkColumnName;
            _tableColumnsQueries = tableColumnsQueries;
        }

        public override string SqlQuery => string.Format(@"CREATE TABLE {0} (
                                                {2}
                                            PRIMARY KEY ({1}))", _entityName, _pkColumnName, _tableColumnsQueries);
    }
}