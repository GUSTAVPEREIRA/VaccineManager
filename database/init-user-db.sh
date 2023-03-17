#!/bin/bash

set -e

psql -v ON_ERROR_STOP=1 --username default --dbname Vaccine <<-EOSQL        
    GRANT ALL PRIVILEGES ON DATABASE Vaccine TO default;    
EOSQL